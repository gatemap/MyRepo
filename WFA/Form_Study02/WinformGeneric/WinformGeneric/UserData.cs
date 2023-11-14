using System.Collections.Generic;

namespace WinformGeneric
{
    internal class UserData
    {
        Dictionary<string, string> userIdPassword;
        Dictionary<string, string> userIdPhone;
        

        public UserData() 
        { 
            userIdPassword = new Dictionary<string, string>();
            userIdPhone = new Dictionary<string, string>();
        }

        /// <summary>
        /// UserData를 아이디/패스워드, 아이디/전화번호 저장해줌
        /// </summary>
        /// <param name="totalData">전체 데이터</param>
        public void SortOutUserData(string totalData)
        {
            string[] dataSplit = totalData.Split('\n');
            foreach (string s in dataSplit)
            {
                if (string.IsNullOrEmpty(s))
                    continue;

                string[] detailData = s.Split(',');
                userIdPassword.Add(detailData[0], detailData[1]);

                // 전화번호가 입력되지 않으면 빈값을 넣어준다
                if(detailData.Length > 2)
                    userIdPhone.Add(detailData[0], detailData[2]);
                else
                    userIdPhone.Add(detailData[0], string.Empty);
            }
        }

        public string CheckLoginSuccess(string userId, string userPassword) 
        {
            if (userIdPassword.ContainsKey(userId) && userIdPassword[userId].Equals(userPassword))
                return userIdPhone[userId];
            else
                return string.Empty;
        }

    }
}
