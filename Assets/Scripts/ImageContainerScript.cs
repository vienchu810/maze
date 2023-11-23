using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageContainerScript : MonoBehaviour
{
  public List<Sprite> imageList = new List<Sprite>();
    public int numberOfObjectsToSpawn = 10; // Số lượng GameObject bạn muốn hiển thị.
    public GameObject tilePrefab; // Prefab bạn muốn sử dụng.

    void Start()
    {
        SpawnRandomImages();
    }

    public void SpawnRandomImages()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            // Tạo một GameObject mới bằng cách sao chép từ prefab đã định nghĩa trước.
            GameObject imageObject = Instantiate(tilePrefab, new Vector3(-0.04f, 2.61f, 0.01707233f), Quaternion.identity, transform);

            // Chọn ngẫu nhiên một ảnh từ danh sách.
            int randomIndex = Random.Range(0, imageList.Count);
            Sprite randomImage = imageList[randomIndex];

            // Thêm component SpriteRenderer để hiển thị ảnh.
            SpriteRenderer spriteRenderer = imageObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                spriteRenderer = imageObject.AddComponent<SpriteRenderer>();
            }
            spriteRenderer.sprite = randomImage;
        }
    }
}
